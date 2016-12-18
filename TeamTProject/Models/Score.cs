namespace TeamTProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Score
    {
        public int ScoreID { get; set; }

        public string User_Name { get; set; }

        public int ScoreAmount { get; set; }

        public string Email { get; set; }
    }
}
