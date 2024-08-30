using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key] 
        public int CommentId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string Mail { get; set; }
        [StringLength(500)]
        public string CommentText { get; set; }

        public bool CommnetStatuse { get; set; }

        public int CommentRating { get; set; }

        public DateTime CommentTime { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blogs { get; set; }

         

        
    }
}
