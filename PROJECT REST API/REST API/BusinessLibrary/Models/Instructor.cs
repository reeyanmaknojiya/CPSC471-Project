﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Models
{
    class Instructor
    {
        #region Contructors

        /// <summary>
        /// Default constructor. 
        /// Need for serialization purposes.
        /// </summary>
        public Instructor()
        {
        }

        /// <summary>
        /// Fields constructor.
        /// </summary>
        public Instructor(int id, DateTime dob, string firstName, string lastName, string trainingType, string trainingPhilosophy, string exerciseModality, int clientPopulation, string accreditation)
        {
            Id = id;
            Dob = dob;
            FirstName = firstName;
            LastName = lastName;
            TrainingType = trainingType;
            TrainingPhilosophy = trainingPhilosophy;
            ExerciseModality = exerciseModality;
            ClientPopulation = clientPopulation;
            Accreditation = accreditation;
        }

        /// <summary>
        /// Clone/Copy constructor.
        /// </summary>
        /// <param name="instance">The object to clone from.</param>
        public Instructor(Instructor instance)
            : this(instance.Id, instance.Dob, instance.FirstName, instance.LastName, instance.TrainingType, instance.TrainingPhilosophy, instance.ExerciseModality, instance.ClientPopulation, instance.Accreditation)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Id generated by our system upon creation of a new instance.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Date of birth of instructor
        /// </summary>
        [JsonProperty(PropertyName = "dob")]
        public DateTime Dob { get; set; }

        /// <summary>
        /// First name of the client.
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the client.
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Instructor's training type
        /// </summary>
        [JsonProperty(PropertyName = "trainingType")]
        public string TrainingType { get; set; }

        /// <summary>
        /// Instructor's training philosophy
        /// </summary>
        [JsonProperty(PropertyName = "trainingPhillosophy")]
        public string TrainingPhilosophy { get; set; }

        /// <summary>
        /// Instructor's exercise modality
        /// </summary>
        [JsonProperty(PropertyName = "exerciseModality")]
        public string ExerciseModality { get; set; }

        /// <summary>
        /// Instructor's number of clientele
        /// </summary>
        [JsonProperty(PropertyName = "clientPopulation")]
        public int ClientPopulation { get; set; }

        /// <summary>
        /// Instructor's credentials/accreditation
        /// </summary>
        [JsonProperty(PropertyName = "accreditation")]
        public string Accreditation { get; set; }

        /// <summary>
        /// Instructor's summarised training info
        /// </summary>
        [JsonProperty(PropertyName = "trainingInfo")]
        public string[] TrainingInfo
        {
            get
            {
                return new string[] {TrainingType, TrainingPhilosophy};
            }
        }

        /// <summary>
        /// FUll name of the client.
        /// </summary>
        [JsonProperty(PropertyName = "fullName")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Overrides the .ToString method.
        /// </summary>
        public override string ToString()
        {
            return FullName;
        }

        #endregion
    }
}
