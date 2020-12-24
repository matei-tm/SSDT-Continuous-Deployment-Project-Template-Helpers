---
name: Publish request
about: Publish main branch
title: 'Publish version x.x.x'
labels: 'publish'
assignees: ''

---

**Publish checklist**

- [ ] Update the src/ssdt-m8-helpers/source.extension.vsixmanifest with the required version
- [ ] Update the changelog
- [ ] Update documentation
  - [ ] README.md
- [ ] Format the code
  - [ ]  On every changed file <kbd>Ctrl</kbd> + <kbd>K</kbd> + <kbd>D</kbd> 
- [ ] Run manual/visual tests 
  - [ ] In Visual Studio, start debugging to open an experimental instance of Visual Studio.
  - [ ] In the experimental instance, go to the Tools menu and click Extensions and Updates. The TestPublish extension should appear in the center pane and be enabled.
  - [ ] On the Tools menu, make sure you see the test command.
- [ ] Run integration tests 
  - [ ] In Visual Studio, from the Test Explorer runt the tests
- [ ] Commit with message `#xxxx. Publish review completed`
- [ ] Merge develop changes into main
  - [ ] Check CI [results](https://travis-ci.org/matei-tm/f-orm-m8) 
- [ ] Publish to the [Visual Studio Marketplace](https://docs.microsoft.com/en-us/visualstudio/extensibility/walkthrough-publishing-a-visual-studio-extension?view=vs-2019#publish-the-extension-to-the-visual-studio-marketplace) 
- [ ] Commit empty ```git commit --allow-empty -m "Completed publish closes #xxxx."```