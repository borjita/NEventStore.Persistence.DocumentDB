﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEventStore.Serialization;

namespace NEventStore.Persistence.DocumentDB
{
    class DocumentPersistenceFactory : IPersistenceFactory
    {
        public DocumentPersistenceFactory(string url, string key, IDocumentSerializer serializer, DocumentPersistenceOptions options)
        {
            this.Url = url;
            this.Key = key;
            this.Serializer = serializer;
            this.Options = options;
        }

        public string Url { get; private set; }
        public string Key { get; private set; }
        public IDocumentSerializer Serializer { get; private set; }
        public DocumentPersistenceOptions Options { get; private set; }

        public IPersistStreams Build()
        {
            return new DocumentPersistenceEngine(this.Options.GetDocumentClient(this.Url, this.Key), this.Serializer, this.Options);
        }
    }
}
