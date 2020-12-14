using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges._2020
{
    class Day_04 : AChallenge2020
    {
        public override string PartOne()
        {
            var passports = GetPassports();

            int validPassports = 0;

            var neccessaryKeys = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            foreach (var passport in passports)
            {
                if (neccessaryKeys.All(k => passport.ContainsKey(k)))
                {
                    validPassports++;
                }
            }

            return $"Valid passports: {validPassports}";
        }

        public override string PartTwo()
        {
            var passports = GetPassports();

            int validPassports = 0;

            var neccessaryKeys = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            foreach (var passport in passports)
            {
                if (neccessaryKeys.All(k => passport.ContainsKey(k)))
                {
                    var hasValidationError = false;
                    foreach (var item in passport)
                    {
                        switch (item.Key)
                        {
                            case "byr":
                                var byr = Convert.ToInt32(item.Value);
                                if (byr < 1920 || 2002 < byr)
                                    hasValidationError = true;
                                break;
                            case "iyr":
                                var iyr = Convert.ToInt32(item.Value);
                                if (iyr < 2010 || 2020 < iyr)
                                    hasValidationError = true;
                                break;
                            case "eyr":
                                var eyr = Convert.ToInt32(item.Value);
                                if (eyr < 2020 || 2030 < eyr)
                                    hasValidationError = true;
                                break;
                            case "hgt":

                                var regex = Regex.Match(item.Value, @"^(\d+)(in|cm)$");

                                if (regex.Success)
                                {
                                    var size = Convert.ToInt32(regex.Groups[1].Value);
                                    if (regex.Groups[2].Value == "in")
                                    {
                                        if (size < 59 || 76 < size)
                                        {
                                            hasValidationError = true;
                                        }
                                    }
                                    else
                                    {
                                        if (size < 150 || 193 < size)
                                        {
                                            hasValidationError = true;
                                        }
                                    }
                                }
                                else
                                {
                                    hasValidationError = true;
                                }

                                break;
                            case "hcl":
                                if (!Regex.Match(item.Value, @"^\#[0-9a-f]{6}$").Success)
                                    hasValidationError = true;
                                break;
                            case "ecl":
                                var validEyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

                                if (!validEyeColors.Contains(item.Value))
                                {
                                    hasValidationError = true;
                                }
                                break;
                            case "pid":
                                if (!Regex.Match(item.Value, @"^([0-9]{9})$").Success)
                                    hasValidationError = true;
                                break;
                            case "cid":
                                break;
                            default:
                                hasValidationError = true;
                                break;
                        }

                        if (hasValidationError)
                        {
                            break;
                        }
                    }


                    if (!hasValidationError)
                    {
                        validPassports++;
                    }
                }
            }

            return $"Valid passports: {validPassports}";
        }

        private List<Dictionary<string, string>> GetPassports()
        {
            var passports = InputText.Split("\r\n\r\n").ToList();

            return passports.Select(k => k.Replace("\r\n", " ")
                .Split(" ")
                .ToDictionary(k => k.Split(":")[0], k => k.Split(":")[1]))
                .ToList();
        }
    }
}
