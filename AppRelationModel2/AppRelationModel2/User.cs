using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRelationModel2
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CompanyInfoKey")]
        public int CompanyInfoKey { get; set; }
        public Company Company { get; set; }
    }
}
