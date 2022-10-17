using PDFGenerator.DeliveryReceipt;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace PDFGenerator
{
    public abstract class TemplateDocument<T> : IDocument
    {
        public T Model { get; }

        public TemplateDocument(T model)
        {
            Model = model;
        }

        public DocumentMetadata GetMetadata()
        {
            DocumentMetadata metadata = DocumentMetadata.Default;
            metadata.Producer = "BufferOrigin";
            return metadata;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(40);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
        }

        public abstract void ComposeHeader(IContainer container);
        public abstract void ComposeContent(IContainer container);
        public abstract void ComposeFooter(IContainer container);
    }
}
