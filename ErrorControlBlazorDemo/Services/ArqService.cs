
namespace ErrorControlBlazorDemo.Services;

public class ArqService
{
  private readonly Random _random = new();

  public List<string> MoPhongStopAndWait(string[] frames, double tyLeMatACK)
  {
    var log = new List<string>();
    for (int i = 0; i < frames.Length; i++)
    {
      log.Add($"📤 Gửi frame {i + 1}: \"{frames[i]}\"");
      bool ackNhan = _random.NextDouble() > tyLeMatACK;

      if (ackNhan)
      {
        log.Add($"✅ ACK nhận thành công cho frame {i + 1}");
      }
      else
      {
        log.Add($"❌ ACK bị mất. Gửi lại frame {i + 1}");
        log.Add($"🔁 Gửi lại frame {i + 1}: \"{frames[i]}\"");
        log.Add($"✅ ACK sau khi gửi lại thành công");
      }
    }
    return log;
  }

  public List<string> MoPhongGoBackN(string[] frames, int windowSize, double tyLeMatACK)
  {
    var log = new List<string>();
    int baseIndex = 0;
    while (baseIndex < frames.Length)
    {
      int end = Math.Min(baseIndex + windowSize, frames.Length);
      log.Add($"📤 Gửi frames từ {baseIndex + 1} đến {end}");

      bool[] ack = new bool[end - baseIndex];
      for (int i = 0; i < ack.Length; i++)
      {
        ack[i] = _random.NextDouble() > tyLeMatACK;
        log.Add($"  ▶ Frame {baseIndex + i + 1}: {(ack[i] ? "✅ ACK nhận" : "❌ ACK mất")}");
      }

      int firstLost = Array.FindIndex(ack, a => !a);
      if (firstLost >= 0)
      {
        log.Add($"🔁 Gửi lại từ frame {baseIndex + firstLost + 1}");
        baseIndex += firstLost;
      }
      else
      {
        baseIndex = end;
      }
    }
    return log;
  }

  public List<string> MoPhongSelectiveRepeat(string[] frames, int windowSize, double tyLeMatACK)
  {
    var log = new List<string>();
    int total = frames.Length;
    bool[] received = new bool[total];
    int baseIndex = 0;

    while (received.Any(r => !r))
    {
      log.Add($"📤 Gửi tối đa {windowSize} frame từ vị trí {baseIndex + 1}");
      for (int i = 0; i < windowSize && baseIndex + i < total; i++)
      {
        int index = baseIndex + i;
        if (received[index]) continue;

        log.Add($"  ▶ Gửi frame {index + 1}: \"{frames[index]}\"");
        if (_random.NextDouble() > tyLeMatACK)
        {
          log.Add($"    ✅ ACK nhận thành công cho frame {index + 1}");
          received[index] = true;
        }
        else
        {
          log.Add($"    ❌ ACK bị mất cho frame {index + 1} → sẽ thử lại");
        }
      }

      baseIndex = Array.FindIndex(received, r => !r);
      if (baseIndex < 0) break;
    }

    log.Add("✅ Tất cả frame đã được nhận thành công.");
    return log;
  }
}
