using UnityEngine;

namespace Tuner.Timer
{
		public delegate void TimerCallback (System.Object state);

		class Timer
		{
				public float mStartTime = -1;
				public float mStopTime = -1;
				public System.Object mState = null;

				public float PassTime {
						get {
								if (mStartTime > 0 && mStopTime > 0) {
										return Time.time - mStartTime;
								} else {
										return 0;
								}
								
						}
				}

				public float RemainTime {
						get {
								if (mStartTime > 0 && mStopTime > 0) {
										return mStopTime - Time.time;
								} else {
										return 0;
								}
								
						}
				}

				public float PassPercent {
						get {
								if (mStartTime > 0 && mStopTime > 0) {
										return	(Time.time - mStartTime) / (mStopTime - mStartTime);
								} else {
										return 0;
								}
						}
				}

				public void Add (float time)
				{
						mStopTime += time;
				}

				public void Lessen (float time)
				{
						mStopTime -= time;
						if (Time.time >= mStopTime) {
								if (mCallback != null) {
										mCallback.Invoke (mState);
								}
				
								mStartTime = -1;			
								mStopTime = -1;
						}
				}

				public float RemainPercent {
						get {
								if (mStartTime > 0 && mStopTime > 0) {
										return	(mStopTime - Time.time) / (mStopTime - mStartTime);
								} else {
										return 1;
								}
						}
				}

				public TimerCallback mCallback = null;

				public Timer (float start, float stop, TimerCallback callback, System.Object state)
				{
						Init (start, stop, callback, state);
				}
				
				public void Init (float start, float stop, TimerCallback callback, System.Object state)
				{
						mStartTime = start;
						mStopTime = stop;
						mCallback = callback;
						mState = state;
				}

				public void Update ()
				{
						if (mStartTime > 0 && mStopTime > 0) {
							
								if (Time.time >= mStopTime) {
								
										
										if (mCallback != null) {
												mCallback.Invoke (mState);
										}

										mStartTime = -1;			
										mStopTime = -1;
								}
						}
				}
		}
}