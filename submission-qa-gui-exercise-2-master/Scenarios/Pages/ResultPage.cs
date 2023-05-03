using FluentAssertions;
using Scenarios.Steps;

namespace Scenarios.Pages
{
    public class ResultPage
    {
        private readonly string _text;

        public ResultPage(string _text)
        {
            _text = text;
        }

        public ResultPage IsCorrectPage()
        {
            GaugeSupport.Driver.Title.Should().StartWith(_text);
            return this;
        }
    }
}