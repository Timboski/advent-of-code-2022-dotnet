namespace Day17;

public class ChamberSimulation
{
    private readonly Chamber _chamber;
    private readonly JetDirectionFactory _jetDirectionFactory;
    private readonly Dictionary<char, Action> _decodeJet;

    public ChamberSimulation(ShapeFactory shapeFactory, JetDirectionFactory jetDirectionFactory)
	{
        _chamber =  new Chamber(shapeFactory);
        _jetDirectionFactory = jetDirectionFactory;

        _decodeJet = new() {
            { '<', _chamber.MoveLeftIfClear},
            { '>', _chamber.MoveRightIfClear}};
    }

    public void DropRock()
    {
        _chamber.AddRock();

        while (true)
        {
            MoveRockForJet();
            if (!_chamber.TryMoveDown()) break;
        }

        _chamber.RestShape();
    }

    private void MoveRockForJet() 
        => _decodeJet[_jetDirectionFactory.NextJetDirection()].Invoke();

    public override string ToString() => _chamber.ToString();
}
