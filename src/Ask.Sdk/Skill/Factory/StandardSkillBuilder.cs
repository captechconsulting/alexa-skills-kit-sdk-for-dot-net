using Alexa.NET.Request;
using Amazon.DynamoDBv2;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.Core.Skill.Factory;
using Ask.Sdk.DynamoDb.Persistence.Adapter.Attributes.Persistence;
using System;

namespace Ask.Sdk.Skill.Factory
{
    public class StandardSkillBuilder : BaseSkillBuilder<StandardSkillBuilder>
    {
        private string _tableName = null;
        private bool _autoCreateTable = true;
        private Func<SkillRequest, string> _partitionKeyGenerator = null;
        private AmazonDynamoDBClient _dynamoDBClient;

        public override CustomSkillConfiguration GetSkillConfiguration()
        {
            var skillConfiguration = base.GetSkillConfiguration();

            skillConfiguration.PersistenceAdapter = string.IsNullOrEmpty(_tableName) ? null :
                DynamoDbPersistenceAdapterFactory.Init(_tableName, _dynamoDBClient,
                createTable: _autoCreateTable, partitionKeyGenerator: _partitionKeyGenerator).Result;

            return skillConfiguration;
        }

        public StandardSkillBuilder WithTableName(string tableName)
        {
            _tableName = tableName;

            return this;
        }

        public StandardSkillBuilder WithAutoCreateTable(bool autoCreateTable)
        {
            _autoCreateTable = autoCreateTable;

            return this;
        }

        public StandardSkillBuilder WithPartitionKeyGenerator(Func<SkillRequest, string> partitionKeyGenerator)
        {
            _partitionKeyGenerator = partitionKeyGenerator;

            return this;
        }

        public StandardSkillBuilder WithDynamoDBClient(AmazonDynamoDBClient dynamoDBClient)
        {
            _dynamoDBClient = dynamoDBClient;

            return this;
        }
    }
}
