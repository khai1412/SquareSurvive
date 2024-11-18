using Extension;
using MidiPlayerTK;

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MidiController : SingletonMono<MidiController>
{
   [SerializeField] int index;
    [SerializeField] MidiFilePlayer player;
    [SerializeField] string midiName;
    [SerializeField] List<long> ticks = new();
    bool isPlaying;
    private void Start()
    {
        index = 0;
        player.MPTK_MidiName = $"{midiName}";
        player.MPTK_Load();
        CreateTicksList();

        //player.MPTK_Play();
    }
    public void CreateTicksList()
    {
        foreach (var e in player.MPTK_MidiEvents)
        {
            if (e.Command == MPTKCommand.NoteOn)
            {
                if (!ticks.Contains(e.Tick))
                {
                    ticks.Add(e.Tick);
                }
            }
        }
    }
    public async void PlayNext_New()
    {
        player.MPTK_Play();
        await Task.Delay(200);
        Debug.Log("Pause");
        player.MPTK_Pause();
    }
    //[Button]
    public async void PlayNext()
    {
        if (isPlaying) return;
        isPlaying = true;
        player.MPTK_TickCurrent = ticks[index];
        player.MPTK_Play();
        index++;
        index = index % ticks.Count;

        await Task.Delay(200);
        player.MPTK_Pause();
        isPlaying = false;
    }
    public async void TestDebug()
    {
        //PlayNext();
        await Task.Delay(200);

        player.MPTK_Pause();
        //player.MPTK_TickCurrent = Random.Range(0, 1000);
    }
}
