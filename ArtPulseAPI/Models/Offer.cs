using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPulseAPI.Models
{
    public class Offer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OfferName { get; set; }
        public string OfferDescription { get; set; }
        public ICollection<OfferProduct> OfferedProducts { get; set; }
    }
}
