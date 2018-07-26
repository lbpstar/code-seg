namespace DatabaseFirst2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        public int Id { get; set; }

        public string Product { get; set; }

        public string UnitPrice { get; set; }

        public int OrderId { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
