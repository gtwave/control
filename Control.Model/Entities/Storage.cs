﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Control.Model.Entities
{
    [DataContract]
    public class Storage : IEntity
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        //Forgein Keys
        public int? ProductID { get; set; }
        
        [ForeignKey("ProductID")]
        public virtual Product ProductUnit { get; set; }

        public int? TypeUnitID { get; set; }

        [ForeignKey("TypeUnitID")]
        public virtual Unit TypeUnit { get; set; }

        public decimal Quantity { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
