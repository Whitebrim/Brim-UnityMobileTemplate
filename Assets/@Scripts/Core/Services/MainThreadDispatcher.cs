using System;
using System.Collections.Generic;
using Core.Infrastructure.Services;
using UnityEngine;

namespace Core.Services
{
    public class MainThreadDispatcher : MonoBehaviour, IService
    {
        private readonly List<Action> _actions = new List<Action>();
        private bool _queued = false;

        public void Dispatch(Action action) {
            lock(_actions) {
                _actions.Add(action);
                 _queued = true;
            }
        }

        void Update()
        {
            if(_queued) {
                Action[] actions = null;

                lock(_actions) {
                    actions = _actions.ToArray();
                    _actions.Clear();
                    _queued = false;
                }

                foreach (Action action in actions)
                    action();
            }
        }
    }
}