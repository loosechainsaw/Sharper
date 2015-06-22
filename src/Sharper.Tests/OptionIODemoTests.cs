using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Sharper.Tests
{
    internal class Student
    {
        public int Id{ get; set; }

        public string Name{ get; set; }
    }

    internal class Score
    {
        public int StudentId{ get; set; }

        public string Name{ get; set; }

        public Decimal Result{ get; set; }
    }

    internal class ScoreServer
    {

        public ScoreServer()
        {
            students = new Dictionary<int, Student>();
            scores = new Dictionary<int, List<Score>>();

            students.Add(1, new Student{ Id = 1, Name = "Blair" });
            students.Add(2, new Student{ Id = 2, Name = "Esther" });

            scores.Add(1, new List<Score> { 
                new Score{ StudentId = 1, Name = "Maths", Result = 76 },
                new Score{ StudentId = 1, Name = "English", Result = 56 },
                new Score{ StudentId = 1, Name = "Science", Result = 67 }
            });

            scores.Add(2, new List<Score> { 
                new Score{ StudentId = 2, Name = "Maths", Result = 87 },
                new Score{ StudentId = 2, Name = "English", Result = 72 },
                new Score{ StudentId = 2, Name = "Science", Result = 59 }
            });
        }

        public IO<String> GetStudentScoreFor(int studentId, string classname)
        {
            var studentT = GetStudentById(studentId).OptionT();
            var studentNameT = studentT.Map(x => x.Name)
                                       .OrElse(new Some<string>(studentId.ToString()));

            var matchedScoreT = from student in studentT
                                         from score in GetClassScoreByStudent(student.ToOption(), classname).OptionT()
                                         select String.Format("Student: {0} Recieved {1} for {2}", student.Name, score.Name, score.Result);

            var result = from name in studentNameT
                                  from text in matchedScoreT.Map(score => score)
                                                   .OrElse(String.Format("Student {0} has not record for {1}", name, classname)
                                                   .ToOption())
                                  select text;

            return result.GetValueOrDefault(String.Empty);
        }

        public IO<Option<Student>> GetStudentById(int studentId)
        {
            return new IO<Option<Student>>(
                () => {
                    Thread.Sleep(TimeSpan.FromSeconds(1.5)); // Simulate work
                    return students.SafeGet(studentId);
                }
            );
        }

        public IO<Option<Score>> GetClassScoreByStudent(Option<Student> student, string @class)
        {
            return new IO<Option<Score>>(
                () => {
                    Thread.Sleep(TimeSpan.FromSeconds(1)); // Simulate work
                    return student.FlatMap(x => scores.SafeGet(x.Id)
                                  .FlatMap(y => y.FirstOrDefault(z => z.Name == @class)
                                  .ToOption()));
                }
            );
        }

        private Dictionary<int,Student> students{ get; set; }

        private Dictionary<int, List<Score>> scores { get; set; }
    }

    [TestFixture]
    public class OptionIODemoTests
    {

        [Test]
        public void Testing_ScoreServer1()
        {
            var server = new ScoreServer();
            var result = server.GetStudentScoreFor(1, "Maths").PerformUnsafeIO();

            Assert.AreEqual(String.Format("Student: {0} Recieved {1} for {2}", "Blair", "Maths", 76), result);
        }

        [Test]
        public void Testing_ScoreServer2()
        {
            var server = new ScoreServer();
            var result = server.GetStudentScoreFor(1, "Mathematics").PerformUnsafeIO();

            Assert.AreEqual(String.Format("Student {0} has not record for {1}", "Blair", "Mathematics"), result);
        }

        [Test]
        public void Testing_ScoreServer3()
        {
            var server = new ScoreServer();
            var result = server.GetStudentScoreFor(3, "Mathematics").PerformUnsafeIO();

            Assert.AreEqual(String.Format("Student {0} has not record for {1}", "3", "Mathematics"), result);
        }
    }

}
