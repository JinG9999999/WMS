using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class PageInfo
    {
        public List<UserInfo> users { get; set; }
        public List<Dept> depts { get; set; }
        public int totalCount { get; set; }  //总记录数
        public int totalPage { get; set; }   //总页数
        public int currentPage { get; set; } //当前页
        public int pageSize { get; set; }  //每页记录数
    }
}
