using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DraftManager
{
    private HarvesterFactory harvesterFactory;
    private Dictionary<string, Provider> providers;
    private Dictionary<string, Harvester> harvesters;
    private ProviderFactory providerFactory;
    private double totalStoredEnergy;
    private double totalMinedOre;
   
    public Mode mode;

    public DraftManager()
    {
        this.harvesterFactory = new HarvesterFactory();
        this.providers = new Dictionary<string, Provider>();
        this.harvesters = new Dictionary<string, Harvester>();
        this.providerFactory = new ProviderFactory();
        this.mode = global::Mode.Full;
    }
    string result = null;
    public string RegisterHarvester(List<string> arguments)
    {
        string id = arguments[1];
        Harvester harvester = this.harvesterFactory.CreateHarvester(arguments);

        harvesters.Add(id, harvester);

        result = $"Successfully registered {arguments[0]} Harvester - {id}";
        return result;

    }

    public string RegisterProvider(List<string> arguments)
    {
        Provider provider = providerFactory.CreateProvider(arguments);
        string id = arguments[1];

        providers.Add(id, provider);

        result = $"Successfully registered {arguments[0]} Provider - {id}";
        return result;
    }

    public string Day()
    {
        StringBuilder sbr = new StringBuilder();
        sbr.AppendLine("A day has passed.");

        double currentEnergy = 0;
        foreach (var provider in providers)
        {
            currentEnergy += provider.Value.EnergyOutput;
        }

        sbr.AppendLine($"Energy Provided: {currentEnergy}");
        totalStoredEnergy += currentEnergy;

        double harvesterTotalConsumption = 0;
        foreach (var harvester in harvesters)
        {
            double currentHarvesterCnsumption = harvester.Value.EnergyRequirement;
           
            harvesterTotalConsumption += currentHarvesterCnsumption;
        }

        if (this.mode == global::Mode.Half)
        {
            harvesterTotalConsumption *= 0.6;
        }
        else if (this.mode == global::Mode.Energy)
        {
            harvesterTotalConsumption = 0;
        }

        if (totalStoredEnergy >= harvesterTotalConsumption)
        {
            double totalHarvestersMined = 0;
            foreach (var harvester in harvesters)
            {
                double currentMined = harvester.Value.OreOutput;

                if (this.mode == global::Mode.Half)
                {
                    currentMined = currentMined * 0.5;
                }
                else if (this.mode == global::Mode.Energy)
                {
                    currentMined = 0;
                }
                totalHarvestersMined += currentMined;
            }
            sbr.AppendLine($"Plumbus Ore Mined: {totalHarvestersMined}");

            totalMinedOre += totalHarvestersMined;
            totalStoredEnergy -= harvesterTotalConsumption;
        }
        else
        {
            sbr.AppendLine($"Plumbus Ore Mined: 0");
        }
        result = sbr.ToString().TrimEnd();
        return result;
    }

    public string Mode(List<string> arguments)
    {
        string modeAsString = arguments[0];
        this.mode = (Mode)Enum.Parse(typeof(Mode), modeAsString);

        result = $"Successfully changed working mode to {mode} Mode";
        return result;
    }

    public string Check(List<string> arguments)
    {
        var builder = new StringBuilder();

        string id = arguments[0];
        Item item;

        if (harvesters.ContainsKey(id))
        {
            item = harvesters[id];

            var harvester = (Harvester)item;
            string type = item is SonicHarvester ? "Sonic" : "Hammer";

            builder.AppendLine($"{type} Harvester - {harvester.Id}");
            builder.AppendLine($"Ore Output: {harvester.OreOutput}");
            builder.Append($"Energy Requirement: {harvester.EnergyRequirement}");
            result = builder.ToString();
            return result;
        }

        if (providers.ContainsKey(id))
        {
            item = providers[id];

            var provider = (Provider)item;
            string type = item is PressureProvider ? "Pressure" : "Solar";

            builder.AppendLine($"{type} Provider - {id}");
            builder.Append($"Energy Output: {provider.EnergyOutput}");

            result = builder.ToString();
            return result;
        }
        result = $"No element found with id - {id}";
        return result;
    }

    public string ShutDown()
    {
        StringBuilder stbr = new StringBuilder();
        stbr.AppendLine("System Shutdown");
        stbr.AppendLine($"Total Energy Stored: {totalStoredEnergy}");
        stbr.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");
        result = stbr.ToString().TrimEnd();
        return result;
    }
}

