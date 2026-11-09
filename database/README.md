# Together Culture Database

This folder contains a **GitHub-safe MySQL/MariaDB schema** for the Together Culture Windows Forms project.

## File

`/database/together_culture_schema.sql`

The SQL file:

- creates the `together_culture` database;
- creates the tables directly used by the current C# code;
- includes the columns expected by the current queries;
- fixes schema/code mismatches found in the original coursework database;
- includes only fictional demo records;
- contains no original user emails, passwords, security answers or personal records.

## Import locally

Using phpMyAdmin:

1. Open phpMyAdmin.
2. Choose **Import**.
3. Select `together_culture_schema.sql`.
4. Run the import.
5. Confirm that a database called `together_culture` appears.

Or with the MySQL command line:

```bash
mysql -u root -p < database/together_culture_schema.sql
```

## Demo accounts

These accounts are fictional and exist only for local testing:

| Role | Email | Password |
| --- | --- | --- |
| Admin | `admin.demo@example.com` | `DemoAdmin123!` |
| Member | `member.demo@example.com` | `DemoMember123!` |
| Non-member | `guest.demo@example.com` | `DemoGuest123!` |

The current coursework prototype compares passwords directly as text. This is **not production-safe**. A production version should hash passwords with a modern password hashing algorithm and never store security answers in plaintext.

## Important code/database alignments

This schema intentionally differs from the old SQL dump in a few places so that it matches the current C# project:

- `eventactivity` contains an `EventName` column because `EventMethods.cs` selects it.
- `PinboardMessages` uses `ID` because `AdminPinboardForm.cs` selects and deletes by `ID`.
- `nonmember.Interests` and `nonmember.Intentions` have blank defaults because the current registration code does not provide those fields.
- `eventactivity.Duration` is an integer because `EventMethods.cs` reads it with `GetInt32()`.

## Database credentials

Do **not** commit your real local MySQL password to GitHub.

The current project contains several hard-coded connection strings using:

```text
Server=127.0.0.1;Database=together_culture;Uid=root;Pwd=;
```

These should be centralised before treating the application as portfolio-ready. See the repository README / project notes for the recommended configuration approach.
