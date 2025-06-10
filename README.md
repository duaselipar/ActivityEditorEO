# Activity Editor EO

A modern open-source editor for Eudemons Online server activity configuration files and task scripts.

## ✨ Features

- Edit and manage `playexplain.ini` and `activitycalendarnew.ini` easily through a user-friendly interface
- Live DataGridView with sorting, searching, and in-place editing
- **Direct integration with MySQL database (`cq_newtaskconfig`):** edit and save trigger scripts (such as `beginscript`) for each event/task directly to your EO server database
- Field-aware editing: only displays editable fields for each event
- Auto-sorting of events by ID on save
- Supports Unicode (Chinese) and GB2312 file encoding
- Designed for both advanced and beginner EO server admins

## 🛢️ MySQL Database Integration

- This tool connects directly to your Eudemons Online server's MySQL database.
- Specifically, it reads from and updates the `cq_newtaskconfig` table.
- You can view and edit the `beginscript` (trigger script) for any event or activity.
- If an event/task is missing from the database, the tool will automatically insert it for you when you save.
- **Make sure you have MySQL credentials with write access!**

| Table             | Usage                                    |
|-------------------|------------------------------------------|
| cq_newtaskconfig  | Reads/writes the `beginscript` column    |

## 🤝 Contributing

Contributions, suggestions, and pull requests are welcome!
Feel free to fork, open issues, or submit changes.

## 📫 Contact & Support

- **Facebook:** [https://www.facebook.com/profile.php?id=61554036273018](https://www.facebook.com/profile.php?id=61554036273018)
- **GitHub:** [https://github.com/duaselipar/ActivityEditorEO](https://github.com/duaselipar/ActivityEditorEO)

---

*This project is open-source and free to use for all EO private server communities.*
