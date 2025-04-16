using System;
using System.Collections.Generic;
using System.IO;
using api_csv.database.models;

namespace api_csv.database
{
	public class dbContext
	{
		private const string PathName = "/Users/igorhaas/Desktop/Paradigmas de Linguagens de Programação - Juliano/Algoritmos/apis/api_csv/animais.txt";

		private readonly List<Animal> _animais = new();

        public dbContext()
		{
			string[] lines = File.ReadAllLines(PathName);

			for (int i = 1; i < lines.Length; i++)
			{
				string[] coluns = lines[i].Split(';');

				Animal animal = new();
				animal.Id = int.Parse(coluns[0]);
				animal.Name = coluns[1]; 
				animal.Classification = coluns[2];
                animal.Origin = coluns[3];
                animal.Reproduction = coluns[4];
                animal.Feedding = coluns[5];

				_animais.Add(animal);

            }

		}

		public List<Animal> Animals => _animais;
	}
}

