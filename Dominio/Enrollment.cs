using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio {
    public static class StateType {
        public const string PENDING = "PENDING";
        public const string APPROVED = "APPROVED";
        public const string REFUSED = "REFUSED";
    }
    public class Enrollment {
        public long ID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public decimal Price { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string State { get; set; }
        public Enrollment() {

        }
        public Enrollment(int userID, int courseID, decimal price) {
            UserID = userID;
            CourseID = courseID;
            Price = price;
            EnrollmentDate = DateTime.Today;
            State = StateType.PENDING;
        }
    }
}
