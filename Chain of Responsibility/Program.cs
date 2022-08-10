
var assistantVcationHandler = new AssistantVacationHandler();
var managerVacationHandler = new ManagerVacationHandler();
var presidentVacationHandler = new PresidentVacationHandler();


assistantVcationHandler.SetNext(managerVacationHandler);
managerVacationHandler.SetNext(presidentVacationHandler);

var request = new VacationRequest() { Days = 12 };
assistantVcationHandler.Process(request);



interface IHandler
{
    void SetNext(IHandler handler);
    void Process(object request);
}

class AssistantVacationHandler : IHandler
{
    private IHandler _nextHandler;
    public void Process(object request)
    {
        var vacationRequest = request as VacationRequest;
        if(vacationRequest.Days <= 3)
        {
            Console.WriteLine($"Assistant approve, vacation days : {vacationRequest.Days}");
        }
        else
        {
            _nextHandler?.Process(request);
        }
    }

    public void SetNext(IHandler handler)
    {
        _nextHandler = handler;
    }
}

class ManagerVacationHandler : IHandler
{
    private IHandler _nextHandler;
    public void Process(object request)
    {
        var vacationRequest = request as VacationRequest;
        if (vacationRequest.Days < 6)
        {
            Console.WriteLine($"Manager approve, vacation days : {vacationRequest.Days}");
        }
        else
        {
            _nextHandler?.Process(request);
        }
    }

    public void SetNext(IHandler handler)
    {
        _nextHandler = handler;
    }
}

class PresidentVacationHandler : IHandler
{
    private IHandler _nextHandler;
    public void Process(object request)
    {
        var vacationRequest = request as VacationRequest;
        if (vacationRequest.Days >= 6)
        {
            Console.WriteLine($"President approve, vacation days : {vacationRequest.Days}");
        }
        else
        {
            _nextHandler?.Process(request);
        }
    }

    public void SetNext(IHandler handler)
    {
        _nextHandler = handler;
    }
}

class VacationRequest
{
    public int Days { get; set; }
}