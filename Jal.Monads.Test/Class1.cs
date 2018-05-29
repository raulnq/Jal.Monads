using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jal.Monads.Test
{
    public interface IPersonRepository
    {
        Person Find(int id);

        Result<Person> FindWithResult(int id);
    }

    public class Person
    {
        
    }

    public class Transaction
    {
        
    }

    public interface INotifier
    {
        void Notify(Transaction transaction, Person person);

        Result NotifyWithResult(Transaction transaction, Person person);
    }

    public interface IBankAccount
    {
        Transaction Charge(Person person, decimal amount);

        AccountSummary SearchAccountSummary(Person person);

        Result<Transaction> ChargeWithResult(Person person, decimal amount);

        Result<AccountSummary> SearchAccountSummaryWithResult(Person person);
    }

    public class AccountSummary
    {
        public decimal Total { get; set; }
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


        public bool ChargeMoneyHappyPath(int id, decimal amount)
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

        public Result ChargeMoneyWithResults(int id, decimal amount)
        {

            IPersonRepository repository = null;

            IBankAccount bankaccount = null;

            INotifier notifier = null;

            return repository.FindWithResult(id)
                .OnSuccess(person => bankaccount.SearchAccountSummaryWithResult(person)
                    .OnSuccess(accountsummary =>
                    {
                        if (accountsummary.Total > amount)
                        {
                            return bankaccount.ChargeWithResult(person, amount)
                                .OnSuccess(transaction => notifier.NotifyWithResult(transaction, person));

                        }
                        else
                        {
                            return Result.Failure(new string[] {});
                        }
                    }));
        }

        public Result ChargeMoneyWithResultsAndRefactoring(int id, decimal amount)
        {

            IPersonRepository repository = null;

            IBankAccount bankaccount = null;

            INotifier notifier = null;

            return repository.FindWithResult(id)
                .OnSuccess(person => bankaccount.SearchAccountSummaryWithResult(person)
                    .OnSuccess(accountsummary => IsThereEnoughMoney(accountsummary, amount))
                    .OnSuccess(() => bankaccount.ChargeWithResult(person, amount))
                    .OnSuccess(transaction => notifier.NotifyWithResult(transaction, person)));
        }

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

        public bool ChargeMoney(int id, decimal amount)
        {

            IPersonRepository repository = null;

            IBankAccount bankaccount = null;

            INotifier notifier = null;
            
            var person = repository.Find(id);

            if (person != null)
            {
                var accountsummary = bankaccount.SearchAccountSummary(person);

                if (accountsummary != null)
                {
                    if (accountsummary.Total > amount)
                    {
                        var transaction = bankaccount.Charge(person, amount);

                        if (transaction != null)
                        {
                            notifier.Notify(transaction, person);

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
    }
}
