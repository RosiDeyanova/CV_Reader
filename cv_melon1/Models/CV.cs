using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace cv_melon1.Models
{

    public class WorkingPlace
    {
        [Key]
        public int id { set; get; }
        public string place { set; get; }

        public WorkingPlace()
        {
            this.place = "none";
        }

        public WorkingPlace(string place)
        {
            this.place = place;
        }

    }

    public class StudyPlace
    {
        [Key]
        public int id { set; get; }
        public string place { set; get; }

        public StudyPlace(string place)
        {
            this.place = place;
        }

        public StudyPlace()
        {
            this.place = "none";
        }
    }

    public class CV
    {
        public CV()
        {
            this.workingPlaces = new List<WorkingPlace>();
            this.studyinPlaces = new List<StudyPlace>();
            this.id = Guid.NewGuid().ToString();
        }

        public string fisrtName { get; set; }
        public string lastName { get; set; }
        public List<WorkingPlace> workingPlaces { get; set; }
        public List<StudyPlace> studyinPlaces { get; set; }
        public string fileText { get; set; }

        [Key]
        public string id { get; set; }

        [NotMapped]
        public IFormFile CvFile { set; get; }




        //public string cvText { get; set; }

        //public CV()
        //{
        //    this.fisrtName = "unknown";
        //    this.lastName = "unknown";
        //    this.workingPlaces[0] = new WorkingPlace();
        //    this.studyinPlaces[0] = new StudyPlace();
        //}

        //public CV(string fisrtName, string lastName, List<string> workingPlaces, List<string> studyinPlaces)
        //{
        //    this.fisrtName = fisrtName;
        //    this.lastName = lastName;
        //    this.workingPlaces = workingPlaces;
        //    this.studyinPlaces = studyinPlaces;
        //}
    }
}
