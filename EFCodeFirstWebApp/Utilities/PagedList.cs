using System.Collections.Generic;
using System.Linq;

namespace EFCodeFirstWebApp.Utilities
{
    /// <summary>
    /// Generic PagedList class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> where T:class
    {
        private List<T> _orgList;
        private readonly int _noPages;
        private int _pageSize;
        private int _minPage = 1;

        public PagedList (List<T> tlist,int pageSize){
    
                _orgList =tlist;
                _pageSize = pageSize;
                if (tlist.Count % _pageSize == 0) {
                    _noPages = tlist.Count / _pageSize;
                }
                else
                {
                    _noPages = tlist.Count / _pageSize + 1;
                }
            }

        public int CurrentPage { get; set; } = 1;
        public int NoPages { get { return _noPages; } }

        /// <summary>
        /// GetListFromPage
        /// </summary>
        /// <param name="pageNo"></param>
        /// <returns>Returns subset based on page index.</returns>
        public List<T> GetListFromPage(int pageNo) {
            int pageCount = _pageSize;
            if (pageNo < _minPage)
            {
                pageNo = _minPage;
            }
            if (pageNo >= _noPages)
            {
                pageNo = _noPages;
                pageCount = _orgList.Count - (_pageSize * (pageNo - 1));
            }
            CurrentPage = pageNo;
            return _orgList.Skip(_pageSize * (pageNo - 1)).Take(pageCount).ToList<T>();
        }
        
    }
}