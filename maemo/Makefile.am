
pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = hildon-sharp.pc

MCS=mcs
RAW_API=hildon-api.raw
API=hildon-api.xml
METADATA=hildon.metadata

ASSEMBLY_NAME= hildon-sharp
ASSEMBLY= $(ASSEMBLY_NAME).dll

#if WINBUILD
#CODEGEN=gapi_codegen.exe
#FIXUP=gapi-fixup.exe
#else
CODEGEN=gapi2-codegen
FIXUP=gapi2-fixup
#endif

build_sources = AssemblyInfo.cs

customs = 
#customs = App.custom Widget.custom Project.custom WidgetClass.custom

CLEANFILES = hildon-sharp.dll generated-stamp generated/*.cs $(API)

DISTCLEANFILES= AssemblyInfo.cs hildon-sharp.pc

noinst_DATA = hildon-sharp.dll

glue_includes = glade.h

all: generated-stamp hildon-sharp.dll

$(API): $(srcdir)/$(RAW_API) $(srcdir)/$(METADATA)
	cp $(srcdir)/$(RAW_API) $(API)
	chmod u+w $(API)
	$(FIXUP) --api=$(srcdir)/$(API) --metadata=$(srcdir)/$(METADATA)

generated-stamp: $(API)
	 $(CODEGEN) --generate $(srcdir)/$(API) $(GTK_SHARP_CFLAGS) --glue-includes=$(glue_includes) --gluelib-name=libhildonsharpglue --glue-filename=../glue/glue.c --outdir=generated --customdir=$(srcdir) --assembly-name=hildon-sharp && touch generated-stamp

hildon-sharp.dll: $(build_sources) generated-stamp
	$(MCS) -nowarn:169 -unsafe -target:library $(GTK_SHARP_LIBS) \
	$(build_sources) generated/*.cs -out:hildon-sharp.dll

install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS)";  \
        $(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS)"; \
        $(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS) || exit 1;

EXTRA_DIST = $(RAW_API) $(sources) $(customs) $(METADATA) AssemblyInfo.cs.in hildon-sharp.dll.config.in hildon-sharp.pc.in $(API)
