using Assets._Project.Develop.Runtime.Utilitis.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Develop.Runtime.Meta.Features.Wallet
{
    public class WalletService
    {
        private readonly Dictionary<CurrencyTypes, ReactiveVariable<int>> _currencies;

        public WalletService(Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies)
        {
            _currencies = new Dictionary<CurrencyTypes, ReactiveVariable<int>>(currencies);
        }

        public List<CurrencyTypes> AvailableCurrencies => _currencies.Keys.ToList();

        public IReadOnlyVariable<int> GetCurrency(CurrencyTypes currencyType) => _currencies[currencyType];

        public bool Enough(CurrencyTypes type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            return _currencies[type].Value >= amount;
        }

        public void Add(CurrencyTypes type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _currencies[type].Value += amount;
        }

        public void Spend(CurrencyTypes type, int amount)
        {
            if(Enough(type, amount) == false)
                throw new InvalidOperationException("Not enough: " + type.ToString());

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            _currencies[type].Value -= amount;
        }
    }
}
