using System;
using CommonDomain.Persistence;
using Documently.Commands;
using Documently.Domain.Domain;
using MassTransit;

namespace Documently.Domain.CommandHandlers
{
	public class CreateDocumentMetaDataHandler : Consumes<CreateNewDocumentMetaData>.All
	{
		private readonly Func<IRepository> _Repo;

		public CreateDocumentMetaDataHandler(Func<IRepository> repo)
		{
			if (repo == null) throw new ArgumentNullException("repo");
			_Repo = repo;
		}

		public void Consume(CreateNewDocumentMetaData command)
		{
		    var document = new Document(command.Title, command.UtcTime);
			_Repo().Save(document, Guid.NewGuid(), null);
		}
	}
}