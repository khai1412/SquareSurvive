using Extension;
using MidiPlayerTK;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MidiController : SingletonMono<MidiController>
{
    int index;
    [SerializeField] MidiFilePlayer player;
    [SerializeField] string midiName;
    [SerializeField] List<long> ticks = new();
    private void Start()
    {
        index = 0;
        player.MPTK_MidiName = $"{midiName}";
        player.MPTK_Load();
        CreateTicksList();
    }
    public void CreateTicksList()
    {
        foreach (var e in player.MPTK_MidiEvents)
        {
            if (e.Command == MPTKCommand.NoteOn )
            {
                if (!ticks.Contains(e.Tick))
                {
                    ticks.Add(e.Tick);
                    Debug.Log(e.Value);
                }
            }
        }
    }
    public void PlayNext()
    {
        player.MPTK_TickCurrent = ticks[index];
        player.MPTK_Play();
        index++;
        index = index % ticks.Count;
    }
    public async void TestDebug()
    {
        //PlayNext();
        await Task.Delay(50);

        player.MPTK_Pause();
        //player.MPTK_TickCurrent = Random.Range(0, 1000);
    }
}
