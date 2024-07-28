﻿namespace AssignmentConsole.Model {
    internal class AssignmentResult {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int Score { get; set; }
        public string Feedback { get; set; }

        public AssignmentResult() { }

        public AssignmentResult(int id, int submissionId, int score, string feedback) {
            Id = id;
            SubmissionId = submissionId;
            Score = score;
            Feedback = feedback;
        }
    }
}