using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DwellingRepository.Database;
using DwellingRepository.Models.Shared;

namespace DwellingRepository.Catalogs
{
    public class ServiceRepository
    {

        private readonly DwellingEntities _db = new DwellingEntities();
        public ServiceRepository(DwellingEntities db)
        {
            _db = db;
        }


        public ICollection<ComboBoxModel> GetCatPeriodicity()
        {
            return _db.Periodicity.Select(e => new ComboBoxModel()
                                                 {
                                                     KeyId = e.PeriodicityId,
                                                     Value = e.Name
                                                 }).ToList();
        }

        public ICollection<ComboBoxModel> GetCatTax()
        {
            return _db.Tax.Where(e=> e.IsObsolete == false).Select(e => new ComboBoxModel()
                                       {
                                           KeyId = e.TaxId,
                                           Value = e.Name
                                       }).ToList();
        }

        public Service GetMetadataById(int? id)
        {
            Service service = _db.Service.Single(e => e.ServiceId == id && e.IsObsolete == false);
            var existTax = _db.TaxServiceRel.Any(e => e.ServiceId == id);
            if (existTax)
            {
                service.ListTax = _db.TaxServiceRel.Where(e => e.ServiceId == id).Select(i => new ComboBoxModel
                                                                                              {
                                                                                                  KeyId = i.TaxId,
                                                                                                  Value = i.Tax.Name
                                                                                              }).ToList();
            }
            return service;
        }

        public ResponseMessageModel ActiveService(int id)
        {
            try
            {
                var service = _db.Service.Single(e => e.ServiceId == id);
                service.IsActive = true;
                _db.SaveChanges();
                return new ResponseMessageModel
                            {
                                HasError = false,
                                Message = "Servicio activado exitosamente",
                                Title = "Activar Servicio"
                            };
            }
            catch (Exception e)
            {
                return new ResponseMessageModel
                       {
                           HasError = true,
                           Message = e.Message,
                           Title = "Error en la operación"
                       };
            }

        }

        public ResponseMessageModel DoObsolete(int id)
        {
            try
            {
                var service = _db.Service.Single(e => e.ServiceId == id);
                service.IsObsolete = true;
                _db.SaveChanges();
                return new ResponseMessageModel
                       {
                           HasError = false,
                           Message = "Servicio borrado exitosamente",
                           Title = "Borrar servicio"
                       };
            }
            catch (Exception e)
            {
                return new ResponseMessageModel
                       {
                           HasError = true,
                           Message = e.Message,
                           Title = "Borrar servicio"
                       };
            }
        }

        public ResponseMessageModel DoDeactive(int id)
        {
            try
            {
                var service = _db.Service.Single(e => e.ServiceId == id);
                service.IsActive = false;
                _db.SaveChanges();
                return new ResponseMessageModel
                {
                    HasError = false,
                    Message = "Servicio borrado exitosamente",
                    Title = "Borrar servicio"
                };
            }
            catch (Exception e)
            {
                return new ResponseMessageModel
                {
                    HasError = true,
                    Message = e.Message,
                    Title = "Borrar servicio"
                };
            }
        }

        public ResponseMessageModel DoUpsert(Service serviceView)
        {
            try
            {
                String message = "",title ="";
                if (serviceView.ServiceId != 0)
                {
                    var service = _db.Service.Single(e => e.ServiceId == serviceView.ServiceId);
                    service.Name = serviceView.Name;
                    service.DaysToPay = serviceView.DaysToPay;
                    service.DaysExtension = serviceView.DaysExtension;
                    service.PeriodStart = serviceView.PeriodStart;
                    service.PeriodEnd = serviceView.PeriodEnd;
                    service.PeriodicityId = serviceView.PeriodicityId;
                    service.Value = serviceView.Value;
                    message = "Servicio modificado exitosamente";
                    title = "Modificar servicio";
                    _db.TaxServiceRel.RemoveRange(_db.TaxServiceRel.Where(e => e.ServiceId == service.ServiceId));
                    _db.SaveChanges();
                }
                else
                {
                    var service = new Service();
                    service.Value = serviceView.Value;
                    service.Name = serviceView.Name;
                    service.DaysToPay = serviceView.DaysToPay;
                    service.DaysExtension = serviceView.DaysExtension;
                    service.PeriodStart = serviceView.PeriodStart;
                    service.PeriodEnd = serviceView.PeriodEnd;
                    service.PeriodicityId = serviceView.PeriodicityId;
                    service.IsActive = true;
                    service.IsObsolete = false;
                    message = "Servicio agregado exitosamente";
                    title = "Agregar servicio";
                    _db.Service.Add(service);
                    _db.SaveChanges();
                    serviceView.ServiceId = service.ServiceId;
                }
                ICollection<TaxServiceRel> listTaxNew = new Collection<TaxServiceRel>();
                if (serviceView.ListTax != null)
                {
                    foreach (ComboBoxModel tax in serviceView.ListTax)
                    {
                        if (tax.KeyId != 0)
                        {
                            listTaxNew.Add(new TaxServiceRel
                                           {
                                               ServiceId = serviceView.ServiceId,
                                               TaxId = tax.KeyId
                                           });
                        }
                    }
                    _db.TaxServiceRel.AddRange(listTaxNew);
                }
                _db.SaveChanges();
                return new ResponseMessageModel
                {
                    HasError = false,
                    Message =message,
                    Title = title
                };

            }
            catch (Exception e)
            {
                return new ResponseMessageModel
                       {
                           HasError = true,
                           Message = e.Message,
                           Title = "Agregar/Editar Servicio"
                       };
            }
        }
    }
    }
