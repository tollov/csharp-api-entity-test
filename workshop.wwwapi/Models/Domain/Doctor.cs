﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Domain
{
    [Table("doctors")]
    public class Doctor
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
