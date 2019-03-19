using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RB.Data.DbModels.Music
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        public int ConcertId { get; set; }

        public Concert Concert { get; set; }

        [Required]
        public bool IsPaid { get; set; }
		
	    public IEnumerable<TicketInShoppingCart> Carts { get; set; } = new List< TicketInShoppingCart >();

    }
}