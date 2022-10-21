using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace API_Tests.Services
{
    public  class Service
    {
        public TypeOfReturn GetTypeOfReturn(int id)
        {
            TypeOfReturn retval = new TypeOfReturn();
            
            using (var db = new Entities())
            {
                var result = from t in db.TypeOfReturn
                             where t.Id == id
                             select t;
                if(result.Count() > 0)
                {
                    retval = result.FirstOrDefault();
                }
                 return retval ;
            }
        }


        public List<TypeOfReturn> GetAllTypeOfReturn()
        {
            List<TypeOfReturn> retval = new List<TypeOfReturn>();

            using (var db = new Entities())
            {
                var result = from t in db.TypeOfReturn
                             select t;
                if (result.Count() > 0)
                {
                    retval = result.ToList<TypeOfReturn>();
                }
                return retval;
            }
        }

        public bool AddTypeOfReturn(TypeOfReturn typeOfReturn)
        {
            try
            {
                using (var db = new Entities())
                {
                    db.Add(typeOfReturn);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                string err = ex.InnerException.ToString();
                return false;
            }
        }

        public bool UpdateTypeOfReturn(TypeOfReturn typeOfReturn)
        {
            try
            {
                using (var db = new Entities())
                {
                    TypeOfReturn result = (from exisisting in db.TypeOfReturn
                                 where exisisting.Id == typeOfReturn.Id
                                           select exisisting).FirstOrDefault();
                    if(result is not null)
                    {
                        result.Name = typeOfReturn.Name;
                        db.SaveChanges();
                        
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<ExternalAPIs> GetAllExternalAPIs()
        {
            List<ExternalAPIs> retval = new List<ExternalAPIs>();

            using (var db = new Entities())
            {
                var result = from t in db.ExternalAPs
                             select t;
                if (result.Count() > 0)
                {
                    retval = result.ToList<ExternalAPIs>();
                }
                return retval;
            }
        }

        public ExternalAPIs GetExternalAPI(int id)
        {
            ExternalAPIs retval = new ExternalAPIs();

            using (var db = new Entities())
            {
                var result = from t in db.ExternalAPs
                             where t.Id == id
                             select t;
                if (result.Count() > 0)
                {
                    retval = result.FirstOrDefault();
                }
                return retval;
            }
        }

        public bool AddExternalAPI(ExternalAPIs externalAPI)
        {
            try
            {
                using (var db = new Entities())
                {
                    db.Add(externalAPI);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                string strError = ex.InnerException.ToString();
                return false;
            }
        }

        public bool UpdateExternalAPI(ExternalAPIs externalAPI)
        {
            try
            {
                using (var db = new Entities())
                {
                    TypeOfReturn result = (from exisisting in db.TypeOfReturn
                                           where exisisting.Id == externalAPI.Id
                                           select exisisting).FirstOrDefault();
                    if (result is not null)
                    {
                        result.Name = externalAPI.Name;
                        db.SaveChanges();

                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool InsertParameter(APIParameters newParamItem)
        {
            bool retval = false;
            try
            {
                using (var db = new Entities())
                {
                    db.Add(newParamItem);
                    db.SaveChanges();
                    retval = true;
                }
            }
            catch (Exception ex)
            {
                string? strError = ex.InnerException.ToString();
            }
            return retval;
        }

         public bool UpdateParameter(APIParameters updateParamItem)
         {
            bool retval = false;
            try
            {
                using (var db = new Entities())
                {
                    APIParameters result = (from existing in db.APIParameters
                                           where existing.Id == updateParamItem.Id
                                           select existing).FirstOrDefault();
                    result = updateParamItem;
                    db.SaveChanges();
                    retval = true;
                }
            }
            catch (Exception ex)
            {
                string? strError = ex.InnerException.ToString();
            }
            return retval;
         }

        public List<APIParameters> GetRelatedAPIParameters(int Id)
        {
            List<APIParameters> retval = new List<APIParameters>();
            using (var db = new Entities())
            {
                var result = from a in db.APIParameters
                                 //join ea in db.ExternalAPs on a.ExternalAPI equals ea.Id
                             where a.Id == Id
                             select a; //new {a.Id,a.ParameterName,a.ParameterValue, ea.id}; 
                if (result.Count() > 0)
                {
                    retval = result.ToList<APIParameters>();
                }
                return retval;
            }
            

        }
    }
}
