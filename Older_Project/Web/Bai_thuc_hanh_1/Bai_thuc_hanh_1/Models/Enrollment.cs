﻿namespace Bai_thuc_hanh_1.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int LearnerID { get; set; }
        public float Grade { get; set; }
        public Learner Learner { get; set;}
        public Course Course { get; set; }
    }
}
