using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;
using DwellingSystemUi.Resources;

namespace DwellingSystemUi.Services
{
    public class DwellingRelService
    {
        private readonly DwellingEntities _db;

        public DwellingRelService(DwellingEntities db)
        {
            _db = db;
        }

        public ResponseMessageModel SaveUpdateDwellingRel(DwellingRel model)
        {
            try
            {

                if (model.DwellingId > 0)
                {
                    var modelDb = _db.DwellingRel.First(e => e.DwellingId == model.DwellingId);

                    modelDb.DwellingApartmentToUse = model.DwellingApartmentToUse;
                    modelDb.DwellingHouseToUse = model.DwellingHouseToUse;
                    modelDb.IsApartment = model.IsApartment;
                    modelDb.LocationId = model.LocationId;
                    modelDb = FixDwellingCollections(modelDb);
                }
                else
                {
                    model = FixDwellingCollections(model);
                    _db.DwellingRel.Add(model);
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
                Debug.WriteLine(e.Message);
                return new ResponseMessageModel
                       {
                           HasError = true,
                           Title = ResShared.TITLE_REGISTER_FAILED,
                           Message = ResShared.ERROR_UNKOWN
                       };
            }
        }

        public DwellingRel FixDwellingCollections(DwellingRel model)
        {

            model.CatLocation = null;

            if (model.IsApartment)// si es departamento
            {
                if (model.DwellingHouse != null && model.DwellingHouse.Count > 0) //limpia la lista de casas
                {
                    for (var i = model.DwellingHouse.Count - 1; i >= 0; i--)
                    {
                        var dwHouse = model.DwellingHouse.ElementAt(i);
                        _db.DwellingHouse.Remove(dwHouse);
                    }
                }

                //se actualiza la lista de departamentos
                if (model.DwellingApartment != null && model.DwellingApartment.Any(e => e.IsObsolete == false))//si ya existe alguna actualizar
                {
                    var dwApartment = model.DwellingApartment.First();
                    
                    dwApartment.InnerNumber = model.DwellingApartmentToUse.InnerNumber;
                    dwApartment.Floor = model.DwellingApartmentToUse.Floor;


                    var apmntBuilding = dwApartment.Building;

                    apmntBuilding.NameBuilding = model.DwellingApartmentToUse.Building.NameBuilding;
                    apmntBuilding.OuterNumber = model.DwellingApartmentToUse.Building.OuterNumber;
                    apmntBuilding.StreetId = model.DwellingApartmentToUse.Building.StreetId;
                    

                }//si no existe alguno, agregar
                else
                {
                    model.DwellingApartment = new List<DwellingApartment> {model.DwellingApartmentToUse};
                }
            }
            else // si es una casa
            {
                if (model.DwellingApartment != null)//limpia la lista de dptos
                {
                    for (var i = model.DwellingApartment.Count - 1; i >= 0; i--)
                    {
                        var dwApartment = model.DwellingApartment.ElementAt(i);
                        _db.DwellingApartment.Remove(dwApartment);
                    }
                }

                if (model.DwellingHouse != null  && model.DwellingHouse.Any(e => e.IsObsolete == false))//actuliza la lista de casas
                {
                    var dweHouse = model.DwellingHouse.First();

                    dweHouse.OuterNumber = model.DwellingHouseToUse.OuterNumber;
                    dweHouse.StreetId = model.DwellingHouseToUse.StreetId;
                }
                else
                {
                    model.DwellingHouse = new List<DwellingHouse> {model.DwellingHouseToUse};
                }
            }

            return model;
        }

        public DwellingRel FillDwellingModel(DwellingRel model)
        {
            if (model.IsApartment)
            {
                model.DwellingApartmentToUse = model.DwellingApartment.FirstOrDefault(m => model.IsObsolete == false);
            }
            else
            {
                model.DwellingHouseToUse = model.DwellingHouse.FirstOrDefault(m => m.IsObsolete == false);
            }

            model.StateName = model.CatLocation.CatMunicipality.CatState.Name;
            model.MunicipalityName = model.CatLocation.CatMunicipality.Name;
            model.LocationName = model.CatLocation.Name;

            return model;
        }
    }
}