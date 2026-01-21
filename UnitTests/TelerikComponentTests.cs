using Telerik.Maui.Controls;
using Telerik.Maui.Controls.Compatibility.Chart;
using Telerik.Maui.Controls.Map;

namespace UnitTestComponents.UnitTests;

public class TelerikComponentTests(ITestOutputHelper testOutputHelper) : BaseViewTest(testOutputHelper)
{
    [Fact]
    public void InitiateControls()
    {
        // Using base view test, we are able to easily instantiate some Telerik controls and verify as needed.
        RadBorder border = new RadBorder();
        Assert.NotNull(border);

        RadButton button = new RadButton();
        Assert.NotNull(button);

        RadCalendar calendar = new RadCalendar();
        Assert.NotNull(calendar);
    }

    // Main goal is to get something like this to work:
    [Fact]
    public void InitiateComplexControls()
    {
        CustomStaticGauge gauge = new();
        Assert.NotNull(gauge);
    }


    // Testing all controls to see all possible errors
    // If there is something to add to BaseViewTest to fix the issues, please advise.

    // =========================
    // Data Controls
    // =========================

    [Fact]
    public void InstantiateCollectionView()
    {
        RadCollectionView control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateDataForm()
    {
        RadDataForm control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateDataGrid()
    {
        RadDataGrid control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateDataPager()
    {
        RadDataPager control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateItemsControl()
    {
        RadItemsControl control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateTreeDataGrid()
    {
        RadTreeDataGrid control = new();
        Assert.NotNull(control);
    }

    // =========================
    // Data Visualization
    // =========================

    [Fact]
    public void InstantiateBarcodes()
    {
        RadBarcode control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateCharts()
    {
        RadCartesianChart control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateGauges()
    {
        RadRadialGauge control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateMap()
    {
        RadMap control = new();
        Assert.NotNull(control);
    }



    [Fact]
    public void InstantiateChatbots()
    {
        RadChat control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateConversationUIChat()
    {
        RadChat control = new();
        Assert.NotNull(control);
    }

    // =========================
    // Editors
    // =========================

    [Fact]
    public void InstantiateAutoComplete()
    {
        RadAutoComplete control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateComboBox()
    {
        RadComboBox control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateDatePicker()
    {
        RadDatePicker control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateDateTimePicker()
    {
        RadDateTimePicker control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateEntry()
    {
        RadEntry control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateImageEditor()
    {
        RadImageEditor control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateListPicker()
    {
        RadListPicker control = new();
        Assert.NotNull(control);
    }



    [Fact]
    public void InstantiateNumericInput()
    {
        RadNumericInput control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateRangeSlider()
    {
        RadRangeSlider control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateRichTextEditor()
    {
        RadRichTextEditor control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateTemplatedPicker()
    {
        RadTemplatedPicker control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateTimePicker()
    {
        RadTimePicker control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateTimeSpanPicker()
    {
        RadTimeSpanPicker control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateSignaturePad()
    {
        RadSignaturePad control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateSlider()
    {
        RadSlider control = new();
        Assert.NotNull(control);
    }

    // =========================
    // Navigation & Layouts
    // =========================

    [Fact]
    public void InstantiateAccordion()
    {
        RadAccordion control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateBottomSheet()
    {
        RadBottomSheet control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateDockLayout()
    {
        RadDockLayout control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateExpander()
    {
        RadExpander control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateNavigationView()
    {
        RadNavigationView control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateSideDrawer()
    {
        RadSideDrawer control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateSlideView()
    {
        RadSlideView control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateTabView()
    {
        RadTabView control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateTreeView()
    {
        RadTreeView control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateWrapLayout()
    {
        RadWrapLayout control = new();
        Assert.NotNull(control);
    }

    // =========================
    // Calendar & Scheduling
    // =========================

    [Fact]
    public void InstantiateCalendar()
    {
        RadCalendar control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateScheduler()
    {
        RadScheduler control = new();
        Assert.NotNull(control);
    }

    // =========================
    // Buttons
    // =========================

    [Fact]
    public void InstantiateButton()
    {
        RadButton control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateCheckBox()
    {
        RadCheckBox control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateSegmentedControl()
    {
        RadSegmentedControl control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateSpeechToTextButton()
    {
        RadSpeechToTextButton control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateTemplatedButton()
    {
        RadTemplatedButton control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateToggleButton()
    {
        RadToggleButton control = new();
        Assert.NotNull(control);
    }

    // =========================
    // Interactivity & UX
    // =========================

    [Fact]
    public void InstantiateAIPrompt()
    {
        RadAIPrompt control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateBadgeView()
    {
        RadBadgeView control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateBorder()
    {
        RadBorder control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateBusyIndicator()
    {
        RadBusyIndicator control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateGridSplitter()
    {
        RadGridSplitter control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiatePath()
    {
        RadPath control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiatePopup()
    {
        RadPopup control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateSkeleton()
    {
        RadSkeleton control = new();
        Assert.NotNull(control);
    }

    [Fact]
    public void InstantiateToolbar()
    {
        RadToolbar control = new();
        Assert.NotNull(control);
    }

    // =========================
    // PDF Viewer
    // =========================

    [Fact]
    public void InstantiatePDFViewer()
    {
        RadPdfViewer control = new();
        Assert.NotNull(control);
    }

    // =========================
    // Document Processing Libraries 
    // =========================

    [Fact]
    public void InstantiatePdfProcessing()
    {
        Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.PdfFormatProvider provider = new();
        Assert.NotNull(provider);
    }



}

