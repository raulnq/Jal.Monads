# Jal.Monads

Just another library that implement monads

## Maybe

## Either

## Result

The Result monad is like the Either monad but limited to return an array of strings in the left side. I want to explain what we are trying to solve using the following example. Imagine that we need to create a class to do the following:
* Search a client by id.
* Search his account summary.
* Validate that are enough credit to charge some new amount.
* Charge the amount.
* Notity the client about the successful transaction.

A first class to fulfil the requirements could be

    public interface IPersonRepository
    {
        Person Find(int id);
    }

    public interface IBankAccount
    {
        Transaction Charge(Person person, decimal amount);

        AccountSummary SearchAccountSummary(Person person);
    }

    public interface INotifier
    {
        void Notify(Transaction transaction, Person person);
    }

    public class VirtualWallet
    {
        private readonly IPersonRepository _repository;

        private readonly IBankAccount _bankaccount;

        private readonly INotifier _notifier;

        public VirtualWallet(IPersonRepository repository, IBankAccount bankaccount, INotifier notifier)
        {
            _repository = repository;
            _bankaccount = bankaccount;
            _notifier = notifier;
        }


        public bool ChargeMoney(int id, decimal amount)
        {

            var person= _repository.Find(id);

            var accountsummary = _bankaccount.SearchAccountSummary(person);

            if (accountsummary.Total > amount)
            {
                var transaction = _bankaccount.Charge(person, amount);

                _notifier.Notify(transaction, person);

                return true;
            }
            else
            {
                return false;
            }

        }
    }

But in a real application this code is not enough to cover all the possible scenarios that could happen during its execution, ending with a code something like this

    public bool ChargeMoney(int id, decimal amount)
    {
        var person = _repository.Find(id);

        if (person != null)
        {
            var accountsummary = _bankaccount.SearchAccountSummary(person);

            if (accountsummary != null)
            {
                if (accountsummary.Total > amount)
                {
                    var transaction = _bankaccount.Charge(person, amount);

                    if (transaction != null)
                    {
                        _notifier.Notify(transaction, person);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }           
        }
        else
        {
            return false;
        }
    }

Now we lost something, the code is not easy to follow like the original one. As you see there a lot of repetitive piece of code suggesting some sort of code smell in our implementation. It's here where the Result class come to rescue us.

    public class Result
    {
        public string[] Errors { get; }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;
    }

    public sealed class Result<T> : Result
    {
        public T Content { get; }
    }
 
The trick here is start to return the Result class on every method on your code in order to build a chain of execution thanks to the following extension methods:

* OnSuccess: The code on this method will be executed only if the IsSuccess flag of the prior execution is true.
* OnFailure: The code on this method will be executed only if the IsFailure flag of the prior execution is true.
* OnBoth: The code on this method will be executed always.

With this in mind we can simplify our code on something like that

    public Result ChargeMoneyWithResults(int id, decimal amount)
    {
        return _repository.Find(id)
            .OnSuccess(person => _bankaccount.SearchAccountSummary(person)
                .OnSuccess(accountsummary =>
                {
                    if (accountsummary.Total > amount)
                    {
                        return _bankaccount.Charge(person, amount)
                            .OnSuccess(transaction => notifier.Notify(transaction, person));

                    }
                    else
                    {
                        return Result.Failure(new string[] {"Not enough money"});
                    }
                }));
    }

This requires changes on the original interfaces

    public interface IPersonRepository
    {
        Result<Person> Find(int id);
    }

    public interface INotifier
    {
        Result Notify(Transaction transaction, Person person);
    }

    public interface IBankAccount
    {
        Result<Transaction> Charge(Person person, decimal amount);

        Result<AccountSummary> SearchAccountSummary(Person person);
    }

And if we do a small refactoring

    public Result IsThereEnoughMoney(AccountSummary accountsummary, decimal amount)
    {
        if (accountsummary.Total > amount)
        {
            return Result.Success();
        }
        else
        {
            return Result.Failure(new string[] { "Not enough money" });
        }
    }

We can end with


    public Result ChargeMoney(int id, decimal amount)
    {
        return repository.Find(id)
            .OnSuccess(person => bankaccount.SearchAccountSummary(person)
                .OnSuccess(accountsummary => IsThereEnoughMoney(accountsummary, amount))
                .OnSuccess(() => bankaccount.Charge(person, amount))
                .OnSuccess(transaction => notifier.Notify(transaction, person)));
    }

At this point the code is readable and has almost the same number of lines of the original that we did.