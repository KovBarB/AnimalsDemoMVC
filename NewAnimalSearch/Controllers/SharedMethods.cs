using NewAnimalSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewAnimalSearch.Controllers
{
    public class SharedMethods
    {
        private AnimalSearchDB db = new AnimalSearchDB();

        public Dictionary<Guid, string> GetPhotos()
        {
            Dictionary<Guid, string> photos = new Dictionary<Guid, string>();
            foreach (Animal a in db.Animals)
            {
                foreach (Photo p in db.Photos)
                {
                    if (a.ProtegeId == p.AnimalID)
                    {
                        photos.Add(a.ProtegeId, p.URL);
                    }
                }
            }
            return photos;
        }

        public List<Animal> GetRandomAnimals()
        {
            List<Animal> randomAnimals = new List<Animal>();

            if (db.Animals.Count() != 0)
            {
                Animal[] list = db.Animals.ToArray();
                Random rd = new Random();

                while (randomAnimals.Count != 3)
                {
                    int rank = rd.Next(0, list.Length - 1);

                    if (!randomAnimals.Contains(list[rank]) /*|| randomAnimals.Count == 0*/)
                    {
                        randomAnimals.Add(list[rank]);
                    }
                }
            }

            return randomAnimals;
        }
    }
}