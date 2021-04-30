using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.Paging
{
    public class SortFilterPageOptions
    {
        public const int DefaultPageSize = 10;   //default page size is 10

        private int _pageSize = DefaultPageSize;

        private int _pageNum = 1;
        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// This is set to the number of pages available based on the number of entries in the query
        /// </summary>
        public int NumPages { get; private set; }

      


        public void SetupRestOfDto<T>(IEnumerable<T> query)
        {
            NumPages = (int)Math.Ceiling(
                (double)query.Count() / PageSize);
            PageNum = Math.Min(
                Math.Max(1, PageNum), NumPages);
          
        }

       

    }
}
