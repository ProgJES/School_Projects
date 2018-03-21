using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        public Manager()
        {
            // If necessary, add constructor code here
        }
        public IEnumerable<EmployeeBase> EmployeeGetAll()
        {
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeBase>>(ds.Employees);
        }
       
        public EmployeeBase EmployeeGetById(int id)
        {
            var identNum = ds.Employees.Find(id);

            return (identNum == null) ? null : Mapper.Map<Employee, EmployeeBase>(identNum);
        }
        public EmployeeBase EmployeeEdit(EmployeeEdit newItem)
        {
            var o = ds.Employees.Find(newItem.EmployeeId);

            if(o == null)
            {
                return null;
            }
            else
            {
                ds.Entry(o).CurrentValues.SetValues(newItem);
                ds.SaveChanges();

                return Mapper.Map<Employee, EmployeeBase>(o);
            }
        }
        //Get all the list of track that ordered by TrackId
        public IEnumerable<TrackBase> TrackGetAll()
        {
            var ordered = ds.Tracks.OrderBy(Tid => Tid.TrackId);
            return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBase>>(ordered);
        }
        //Get all the pop
        public IEnumerable<TrackBase> TrackGetAllPop(int gid)
        {
            var pop = ds.Tracks.Where(pp => pp.GenreId == 9).OrderBy(Tname => Tname.Name);
            return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBase>>(pop);
        }
        //Get all the DeepPurple
       public IEnumerable<TrackBase> TrackGetAllDeepPurple()
        {
            var deepPurple = ds.Tracks.Where(dp => dp.Composer.Contains("John Lord"));
            deepPurple = deepPurple.OrderBy(Tid => Tid.TrackId);
            return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBase>> (deepPurple);
        }
        //Get all Top100Longest
       public IEnumerable<TrackBase> TrackGetAllTop100Longest()
        {
            var longest = ds.Tracks.OrderByDescending(lg => lg.Milliseconds).Take(100);
            longest = longest.OrderBy(Tid => Tid.TrackId);
            return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBase>>(longest);
        }
        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()
    }
}