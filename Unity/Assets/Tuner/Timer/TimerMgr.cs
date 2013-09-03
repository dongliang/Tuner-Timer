using UnityEngine;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Tuner.Timer
{
		public class TimerMgr:Tuner.Singleton<TimerMgr>
		{
				
				Dictionary<string,Timer> mTimers = new Dictionary<string, Timer> ();

				public void Add (string name, float time, TimerCallback callback, System.Object state)
				{
						
						float triggerTime = Time.time + time;
						Timer temp = null;
						if (!mTimers.TryGetValue (name, out temp)) {
								temp = new Timer (Time.time, triggerTime, callback, state);
								mTimers.Add (name, temp);
						} else {
								temp.Init (Time.time, triggerTime, callback, state);
						}
				}

				public void Remove (string name)
				{
						mTimers.Remove (name);
				}
				
				void AddTime (string name, float time)
				{
						Timer temp = null;
						if (mTimers.TryGetValue (name, out temp)) {
								temp.Add (time);
						}
				}

				void LessenTime (string name, float time)
				{
						Timer temp = null;
						if (mTimers.TryGetValue (name, out temp)) {
								temp.Lessen (time);
						}
				}

				public float PassTime (string name)
				{
						Timer temp = null;
						if (mTimers.TryGetValue (name, out temp)) {
								return temp.PassTime;
						}
						return 0;
				}

				public float PassPercent (string name)
				{
						Timer temp = null;
						if (mTimers.TryGetValue (name, out temp)) {
								return temp.PassPercent;
						}
						Debug.Log ("3333");
						return 0;
				}

				public float RemainPercent (string name)
				{
						Timer temp = null;
						if (mTimers.TryGetValue (name, out temp)) {
								return temp.RemainPercent;
						}
						return 1;
				}

				public float RemainTime (string name)
				{
						Timer temp = null;
						if (mTimers.TryGetValue (name, out temp)) {
								return temp.RemainTime;
						}
						return 0;
				}

				public void Update ()
				{
						foreach (KeyValuePair<string,Timer> item in mTimers) {
								item.Value.Update ();
						}
				}
		}
}
