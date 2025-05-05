using Task_01.Domain.Models;

var document = new Document("This is a sample text document.");
var webPage = new Webpage("<html><body>This is a sample web page.</body></html>");

document.Search("simple");
webPage.Search("web");


