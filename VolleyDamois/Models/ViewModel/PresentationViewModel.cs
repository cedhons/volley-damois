using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models.ViewModel
{
    public class PresentationViewModel<K, T>
    {
        private IDictionary<K, IList<T>> _dictionary;

        public PresentationViewModel(IDictionary<K, IList<T>> teamsDictionary)
        {
            _dictionary = teamsDictionary;
        }

        public IList<T> this[K key] => _dictionary[key];
        public ICollection<K> Keys => _dictionary.Keys;
    }
}
