using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WinCore.Sys
{
  public class SystemPath : List<string>
  {
    private string raw;

    public SystemPath()
      : base()
    {
      this.raw = System.Environment.GetEnvironmentVariable("PATH").Trim();

      MatchCollection matches = new Regex("([^\";]*|\"([^\"]|\"\")+\")").Matches(raw);
      foreach (Match match in matches)
      {
        var path = match.Value.Trim();
        if (path.Length > 0)
        {
          this.Add(match.Value);
        }
      }
    }
  }
}
