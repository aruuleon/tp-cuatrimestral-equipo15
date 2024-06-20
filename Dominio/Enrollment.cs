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
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal Price { get; set; }
        public string State { get; set; }
        public Enrollment() {

        }
        public Enrollment(int id, int userID, int courseID, DateTime enrollmentDate, decimal price) {
            ID = id;
            UserID = userID;
            CourseID = courseID;
            EnrollmentDate = enrollmentDate;
            Price = price;
            State = StateType.PENDING;
        }
    }
}
