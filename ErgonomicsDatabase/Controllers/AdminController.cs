using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ErgonomicsDatabase.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErgonomicsDatabase.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AddEntry()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddEntry(IFormCollection entryForm)
        {
            
            try
            {
                using (PrototypeDatabaseContext db = new PrototypeDatabaseContext())
                {
                    TForceType forceType = new TForceType
                    {
                        VcForce = entryForm["torqueType"]
                    };
                    int forceTypeId;

                    db.TForceType.Add(forceType); 
                    db.SaveChanges();

                    forceTypeId = db.TForceType.Last().IForceTypeId;
                    TForce force = new TForce
                    {
                        IForceTypeId = forceTypeId,

                        IForceType = forceType
                    };
                    THand hand = db.THand.Where(x => x.VcHand == entryForm["hand"]).FirstOrDefault();
                    bool isDominant = true;
                    if (entryForm["isDominant"] == "false")
                    {
                        isDominant = false;
                    }
                    THandedness handedness = new THandedness
                    {
                        IHandId = hand.IHandId,
                        BIsDominant = isDominant,

                        IHand = hand
                    };
                    TRotationAxis rotationAxis = db.TRotationAxis.Where(x => x.VcRotationAxis == entryForm["rotationAxis"]).FirstOrDefault();

                    int rotationAxisId = db.TRotationAxis.Last().TiRotationAxisId;

                    TObjectHandle objectHandle = new TObjectHandle
                    {
                        TiRotationAxisId = Convert.ToByte(rotationAxisId),
                        VcObjectHandle = entryForm["objectHandle"],

                        TiRotationAxis = rotationAxis
                    };
                    TPosture posture = new TPosture
                    {
                        VcPostureDetails = entryForm["posture"]
                    };
                    TProcedure procedure = new TProcedure
                    {
                        VcProcedure = entryForm["dataCollection"]
                    };
                    int forceId;
                    int handednessId;
                    int objectHandleId;
                    int postureId;
                    int procedureId;
                        db.TForce.Add(force);
                        db.THandedness.Add(handedness);
                        db.TObjectHandle.Add(objectHandle);
                        db.TPosture.Add(posture);
                        db.TProcedure.Add(procedure);
                        db.SaveChanges();

                        forceId = db.TForce.Last().IForceId;
                        handednessId = db.THandedness.Last().IHandednessId;
                        objectHandleId = db.TObjectHandle.Last().IObjectHandleId;
                        postureId = db.TPosture.Last().IPostureId;
                        procedureId = db.TProcedure.Last().IProcedureId;

                    TAction action = new TAction
                    {
                        IForceId = forceId,
                        IHandednessId = handednessId,
                        IObjectHandleId = objectHandleId,
                        IPostureId = postureId,
                        IProcedureId = procedureId,

                        IForce = force,
                        IHandedness = handedness,
                        IObjectHandle = objectHandle,
                        IPosture = posture,
                        IProcedure = procedure
                    };
                    TStrengthData strengthData = new TStrengthData
                    {
                        FMeanMale = Convert.ToDouble(entryForm["maleMean"]),
                        FMeanFemale = Convert.ToDouble(entryForm["femaleMean"]),
                        FSdmale = Convert.ToDouble(entryForm["maleSD"]),
                        FSdfemale = Convert.ToDouble(entryForm["femaleSD"])
                    };
                    int actionId;
                    int strengthDataId;
                        db.TAction.Add(action);
                        db.TStrengthData.Add(strengthData);
                        db.SaveChanges();

                        actionId = db.TAction.Last().IActionId;
                        strengthDataId = db.TStrengthData.Last().IStrengthDataId;
                    int year = Convert.ToInt32(entryForm["year"]);
                    DateTime studyYear = new DateTime(year, 1, 1);
                    TStudy study = new TStudy
                    {
                        IActionId = actionId,
                        IStrengthDataId = strengthDataId,
                        DtStudyYear = studyYear,
                        VcSource = entryForm["source"],
                        BArchived = false,
                        IStudyFileId = 0,

                        IAction = action,
                        IStrengthData = strengthData
                    };
                    TSubject subject = new TSubject
                    {
                        TiMaleSubjectCount = Convert.ToByte(entryForm["maleNumber"]),
                        TiFemaleSubjectCount = Convert.ToByte(entryForm["femaleNumber"]),
                        VcSubjectDescription = entryForm["subjectDescription"],
                        TiSubjectAgeRangeEnd = Convert.ToByte(entryForm["ageMax"]),
                        TiSubjectAgeRangeBegin = Convert.ToByte(entryForm["ageMin"])
                    };
                    int studyId;
                    int subjectId;
                        db.TStudy.Add(study);
                        db.TSubject.Add(subject);
                        db.SaveChanges();

                        studyId = db.TStudy.Last().IStudyId;
                        subjectId = db.TSubject.Last().ISubjectId;

                    TStudySubject studySubject = new TStudySubject
                    {
                        IStudyId = studyId,
                        ISubjectId = subjectId,

                        ISubject = subject,
                        IStudy = study
                    };
                        db.TStudySubject.Add(studySubject);
                     
                        db.SaveChanges();

                }
            } catch (Exception e)
            {

            }
            return View();
        }
    }
}
