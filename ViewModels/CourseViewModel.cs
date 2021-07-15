using BS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BS.ViewModels
{
    public class CourseViewModel
    {
		public int Id { get; set; }
		[Required]
		public string Place { get; set; }
		[Required]
		public string Date { get; set; }
		[Required]
		[ValidTime]
		public string Time { get; set; }
		[Required]
		public byte Category { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public string Heading { get; set; }
		public string Action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }
        public IQueryable<Course> UpcommingCourses { get; internal set; }
        public bool ShowAction { get; internal set; }

        public DateTime GetDateTime()
		{
			return DateTime.Parse(string.Format("{0} {1}", Date, Time));
		}
	}
}
