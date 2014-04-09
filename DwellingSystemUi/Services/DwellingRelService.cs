using System;
using System.Collections.Generic;
using DwellingRepository.Common;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;
using DwellingSystemUi.Resources;

namespace DwellingSystemUi.Services
{
    public class DwellingRelService
    {
        public ResponseMessageModel SaveUpdateDwellingRel(DwellingRel model)
        {
            try
            {
                if (model.IsApartment)
                {
                    if (model.DwellingApartment == null)
                    {
                        model.DwellingApartment = new List<DwellingApartment> { model.DwellingApartmentToUse };
                    }
                    else
                    {
                        model.DwellingApartment.Clear();
                        model.DwellingApartment.Add(model.DwellingApartmentToUse);
                    }

                    if (model.DwellingHouse != null)
                    {
                        foreach (var it in model.DwellingHouse)
                        {
                            it.IsObsolete = true;
                        }
                    }
                }
                else
                {
                    if (model.DwellingHouse == null)
                    {
                        model.DwellingHouse = new List<DwellingHouse> { model.DwellingHouseToUse };
                    }
                    else
                    {
                        model.DwellingHouse.Clear();
                        model.DwellingHouse.Add(model.DwellingHouseToUse);
                    }

                    if (model.DwellingApartment != null)
                    {
                        foreach (var it in model.DwellingApartment)
                        {
                            it.IsObsolete = true;
                        }
                    }
                }

                var repository = new GenericRepository<DwellingRel>();

                if (model.DwellingId == EntityConstants.NULL_VALUE)
                {
                    repository.Add(model);
                }
                else
                {
                    repository.Update(model);
                }

                return new ResponseMessageModel
                       {
                           HasError = false,
                           Title = ResShared.TITLE_REGISTER_SUCCESS,
                           Message = ResShared.INFO_REGISTER_SAVED
                       };

            }

            catch (Exception)
            {
                return new ResponseMessageModel
                       {
                           HasError = true,
                           Title = ResShared.TITLE_REGISTER_FAILED,
                           Message = ResShared.ERROR_UNKOWN
                       };
            }
        }
    }
}