using Ask.Sdk.Core.Attributes.Persistence;
using Ask.Sdk.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ask.Sdk.Core.Attributes
{
    public static class AttributesManagerFactory
    {
        public static IAttributesManager Init(RequestEnvelope requestEnvelope, IPersistenceAdapter persistenceAdapter = null)
        {
            return new AttributesManager(requestEnvelope, persistenceAdapter);
        }
    }
    internal class AttributesManager : IAttributesManager
    {
        private readonly RequestEnvelope _requestEnvelope;
        private readonly IPersistenceAdapter _persistenceAdapter;
        private IDictionary<string, object> _requestAttributes = new Dictionary<string, object>();
        private IDictionary<string, object> _sessionAttributes;
        private IDictionary<string, object> _persistentAttributes = new Dictionary<string, object>();
        private bool _persistentAttributeSet = false;

        internal AttributesManager(RequestEnvelope requestEnvelope, IPersistenceAdapter persistenceAdapter = null)
        {
            _requestEnvelope = requestEnvelope ?? throw new ArgumentNullException(nameof(requestEnvelope));
            _persistenceAdapter = persistenceAdapter;
            if (_requestEnvelope.Session != null)
            {
                _sessionAttributes = _requestEnvelope.Session.Attributes ?? new Dictionary<string, object>();
            }
        }

        public async Task<IDictionary<string, object>> GetPersistentAttributes()
        {
            if (_persistenceAdapter == null)
            {
                throw new MissingMemberException("AttributesManager", "_persistenceAdapter");
            }

            if (!_persistentAttributeSet)
            {
                _persistentAttributes = await _persistenceAdapter.GetAttributes(_requestEnvelope);
                _persistentAttributeSet = true;
            }

            return _persistentAttributes;
        }

        public Task<IDictionary<string, object>> GetRequestAttributes()
        {
            return Task.FromResult(_requestAttributes);
        }

        public Task<IDictionary<string, object>> GetSessionAttributes()
        {
            if (_sessionAttributes == null)
            {
                throw new MissingMemberException("RequestEnvelope", "Session");
            }

            return Task.FromResult(_sessionAttributes);
        }

        public async Task SavePersistentAttributes()
        {
            if (_persistenceAdapter == null)
            {
                throw new MissingMemberException("AttributesManager", "_persistenceAdapter");
            }

            if (_persistentAttributeSet)
            {
                await _persistenceAdapter.SaveAttributes(_requestEnvelope, _persistentAttributes);
            }
        }

        public Task SetPersistentAttributes(IDictionary<string, object> persistentAttributes)
        {
            if (_persistenceAdapter == null)
            {
                throw new MissingMemberException("AttributesManager", "_persistenceAdapter");
            }

            _persistentAttributes = persistentAttributes;
            _persistentAttributeSet = true;

            return Task.CompletedTask;
        }

        public Task SetRequestAttributes(IDictionary<string, object> requestAttributes)
        {
            _requestAttributes = requestAttributes;

            return Task.CompletedTask;
        }

        public Task SetSessionAttributes(IDictionary<string, object> sessionAttributes)
        {
            if (_sessionAttributes == null)
            {
                throw new MissingMemberException("RequestEnvelope", "Session");
            }

            _sessionAttributes = sessionAttributes;

            return Task.CompletedTask;
        }
    }
}
