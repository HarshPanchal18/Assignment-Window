using System;

namespace AssignmentConsole.Model {
    internal class AssignmentSubmission {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Content { get; set; }
        public bool IsSubmitted { get; set; }

        public AssignmentSubmission() { }

        public AssignmentSubmission(int id, int assignmentId, int studentId, DateTime submissionDate, string content) {
            Id = id;
            AssignmentId = assignmentId;
            StudentId = studentId;
            SubmissionDate = submissionDate;
            Content = content;
            IsSubmitted = true; // Default to true upon creation
        }
    }
}