﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;
using DwellingSystemUi.Resources;

namespace DwellingSystemUi.Services
{
    public class ResidentService
    {

        private readonly DwellingEntities _db;

        public ResidentService(DwellingEntities db)
        {
            _db = db;
        }

        public ResponseMessageModel SaveUpdateResident(Resident model)
        {
            try
            {
                if (model.ResidentId > 0)
                {
                    var modelDb = _db.Resident.First(m => m.ResidentId == model.ResidentId);
                    modelDb = this.UpdateResidentValues(modelDb,model);
                }
                else
                {
                    model.DwellingResidentRel = new Collection<DwellingResidentRel>();
                    model.DwellingResidentRel.Add(model.DwellingResidentRelToUSe);
                    _db.Resident.Add(model);
                }

                _db.SaveChanges();

                return new ResponseMessageModel
                {
                    HasError = false,
                    Title = ResShared.TITLE_REGISTER_SUCCESS,
                    Message = ResShared.INFO_REGISTER_SAVED
                };
            }
            catch (Exception e)
            {
                return new ResponseMessageModel
                {
                    HasError = true,
                    Title = ResShared.TITLE_REGISTER_FAILED,
                    Message = ResShared.ERROR_UNKOWN
                };
            }
        }

        public Resident UpdateResidentValues(Resident modelDb,Resident model)
        {
            model.DwellingResidentRel = new Collection<DwellingResidentRel> {model.DwellingResidentRelToUSe};

            modelDb.Name = model.Name;
            modelDb.LastName = model.LastName;
            modelDb.Email = model.Email;
            modelDb.Email2 = model.Email2;
            modelDb.PhoneNumber = model.PhoneNumber;
            modelDb.MobileNumber = model.MobileNumber;
            modelDb.MobileNumber2 = model.MobileNumber2;
            modelDb.OfficeNumber = model.OfficeNumber;
            modelDb.DocumentTypeId = model.DocumentTypeId;
            modelDb.DocumentNumber = model.DocumentNumber;
            modelDb.Gender = model.Gender;
            modelDb.Image = model.Image;
            modelDb.BirthDay = model.BirthDay;
            modelDb.Comments = model.Comments;

            return modelDb;
        }
    }
}