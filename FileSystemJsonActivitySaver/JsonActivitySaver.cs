using Newtonsoft.Json;
using PlayerActivity.Contracts.Interfaces;
using PlayerActivity.Contracts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PlayerActivity.FileSystemJsonActivitySaver
{
	public class JsonActivitySaver : IActivityRepository, IDisposable
	{
		private Boolean _disposed;
		private readonly String _outputFilePath;
		private readonly Encoding _fileEncoding;
		private readonly List<Activity> _allPlayerActivities;


		public JsonActivitySaver(String outputFilePath, Encoding fileEncoding)
		{
			_outputFilePath = outputFilePath;
			_fileEncoding = fileEncoding;
			_allPlayerActivities = ReadActivities().ToList();
		}
		~JsonActivitySaver()
		{
			Dispose(false);
		}


		// IActivityRepository /////////////////////////////////////////////////////////////////////////
		public void AddOrUpdate(Activity playerActivity)
		{
			lock(_allPlayerActivities)
			{
				var currentPlayerActivity = _allPlayerActivities.FirstOrDefault(p => p.PlayerId == playerActivity.PlayerId);
				if(currentPlayerActivity != null)
				{
					currentPlayerActivity.Type = playerActivity.Type;
					currentPlayerActivity.Name = playerActivity.Name;
				}
				else
				{
					_allPlayerActivities.Add(playerActivity);
				}
			}
		}


		// IDisposable ////////////////////////////////////////////////////////////////////////////
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(Boolean disposing)
		{
			if(!_disposed)
			{
				WriteActivities();
				if(disposing)
				{

				}

				_disposed = true;
			}
		}


		// FUNCTIONS //////////////////////////////////////////////////////////////////////////////
		private Activity[] ReadActivities()
		{
			if(File.Exists(_outputFilePath))
			{
				using(var stream = new FileStream(_outputFilePath, FileMode.OpenOrCreate, FileAccess.Read))
				{
					using(var streamReader = new StreamReader(stream, _fileEncoding))
					{
						using(var textReader = new JsonTextReader(streamReader))
						{
							var activities = new JsonSerializer().Deserialize<Activity[]>(textReader);
							if(activities != null)
								return activities;
						}
					}
				}
			}

			return new Activity[] { };
		}
		private void WriteActivities()
		{
			using(var stream = new FileStream(_outputFilePath, FileMode.Create, FileAccess.Write))
			{
				using(var streamWriter = new StreamWriter(stream, _fileEncoding))
				{
					using(var textWriter = new JsonTextWriter(streamWriter))
					{
						new JsonSerializer().Serialize(textWriter, _allPlayerActivities, typeof(Activity[]));
					}
				}
			}
		}
	}
}