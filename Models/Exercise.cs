using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string OwnerID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Conditions { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Tags { get; set; }
        public string Pictures { get; set; }
        [Required]
        public string RightAnswers { get; set; }
        public SolutionStatus Status { get; set; } 
        public string UsersSolved { get; set; }
    }
    public enum SolutionStatus
    {
        Correct,
        Incorrect,
        Not_applied
    }
}